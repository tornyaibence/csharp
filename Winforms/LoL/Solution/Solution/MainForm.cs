namespace Solution;
public partial class MainForm : Form
{
    private BindingSource adapter = new BindingSource();

    //olyan mutat�. amely �rt�ke csak olyan f�ggv�ny lehet, melynek nincs param�tere �s a visszat�r�si �rt�ke void
    //void AddNewChampion()
    //void UpdateChapion()
    private delegate void Action();

    //A mutat� (function pointer) p�d�nya
    private Action action;

    public MainForm()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        PopulateRoleComboBox();
        PopulateDataGridView();
    }



    private void UpdateChampion()
    {
        ChampionViewModel model = (ChampionViewModel)adapter.Current;

        using AppDbContext context = new AppDbContext();

        Champion champion = context.Champions.Find(model.Id);
        model.Name = textBoxName.Text.Trim();
        model.Hp = int.Parse(textBoxHp.Text.Trim());
        model.Mana = int.Parse(textBoxMana.Text.Trim());
        model.DateOfRelease = dateTimePickerDateOfRelease.Value;
        model.RoleId = (int)comboBoxRole.SelectedValue;
        model.ToDbEntity(champion);
        context.SaveChanges();

        int index = adapter.IndexOf(model);
        adapter.RemoveAt(index);
        adapter.Insert(index, model);

        ClearForm();
    }

    #region helper functions

    private void PopulateForm(ChampionViewModel model)
    {
        textBoxName.Text = model.Name;
        textBoxHp.Text = model.Hp.ToString();
        textBoxMana.Text = model.Mana.ToString();
        dateTimePickerDateOfRelease.Value = model.DateOfRelease;
        comboBoxRole.SelectedValue = model.RoleId;
    }

    private void ClearForm()
    {
        textBoxName.Text = String.Empty;
        textBoxHp.Text = String.Empty;
        textBoxMana.Text = String.Empty;
        dateTimePickerDateOfRelease.Value = DateTime.Now;
        comboBoxRole.SelectedIndex = 0;
    }

    private void PopulateDataGridView()
    {
        using AppDbContext context = new AppDbContext();
        adapter.DataSource = context.Champions.Include(x => x.Role)
                                                                           .Select(x => new ChampionViewModel(x))
                                                                           .ToList();
        dataGridView.DataSource = adapter;
    }

    private void PopulateRoleComboBox()
    {
        using AppDbContext context = new AppDbContext();
        comboBoxRole.DataSource = context.Roles.ToList();
        comboBoxRole.DisplayMember = "Name";
        comboBoxRole.ValueMember = "Id";
    }

    private void AddNewChampion()
    {
        ChampionViewModel model = new ChampionViewModel
        {
            Name = textBoxName.Text.Trim(),
            Hp = int.Parse(textBoxHp.Text.Trim()),
            Mana = int.Parse(textBoxMana.Text.Trim()),
            DateOfRelease = dateTimePickerDateOfRelease.Value,
            RoleId = (int)comboBoxRole.SelectedValue
        };
        Champion champion = model.ToDbEntity();
        using AppDbContext context = new AppDbContext();
        context.Champions.Add(champion);
        context.SaveChanges();

        

        adapter.Add(new ChampionViewModel(champion));
    }
    #endregion

    #region event hanglers
    private void OnAddClick(object sender, EventArgs e)
    {
        //az action function printer megkapja az UpdateChampion mem�riacym�t de nem hajtja v�ggre
        action = AddNewChampion; 
        formGroup.Enabled = true;
    }

    private void OnUpdateClick(object sender, EventArgs e)
    {
        ChampionViewModel model = (ChampionViewModel)adapter.Current;

        if (model == null)
        {
            MessageBox.Show("Figyelem!", " Nem jel�lt ki h�st!", MessageBoxButtons.OK);
            return;
        }

        PopulateForm(model);
    }

    private void OnDeleteClick(object sender, EventArgs e)
    {

    }

    private void OnSumbitClick(object sender, EventArgs e)
    {
        //V�grehajtjuk a f�ggv�nyt amelyre az action pointer mutat
        //ezeket a f�ggv�nyeket (mem�riac�meket) az OnAddClick vagy OnUpdateClick f�ggv�nyekben defini�ltuk
        action();
        formGroup.Enabled = false;
    }

    #endregion
}