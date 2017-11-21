using System;
using System.Windows.Forms;
using ZDPress.Opc;

using ZDPress.UI.ViewModels;

namespace ZDPress.UI.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
      

        private void OnShowAutomateModeClick()
        {
            ShowFunctionSelectForm();
        }


        private void ShowFunctionSelectForm()
        {
            Cursor.Current = Cursors.WaitCursor;

            OpcResponderSingleton.Instance.WriteBitToOpc(BitParameters.AvtomatRezhim, true);

            Cursor.Current = Cursors.Default;


            Form mdiParent = UiHelper.GetMdiContainer(this);

            Form form = UiHelper.GetFormSingle(typeof(FunctionSelectForm));

            UiHelper.ShowForm(form, mdiParent);
        }

     
        private void zdButton13_Click(object sender, EventArgs e)
        {
            OnChartClick();
        }


        private void OnChartClick()
        {
            ShowChartForm();
        }


        private void ShowChartForm()
        {
            Form mdiParent = UiHelper.GetMdiContainer(this);

            ChartForm form = (ChartForm)UiHelper.GetFormSingle(typeof(ChartForm));

            ChartFormViewModel viewModel = new ChartFormViewModel 
            {
                PressOperation = OpcLayer.CurrentPressOperation//TODO: подумать как лучше брать текущую операцию
            };
            form.buttonSaveOperation.Visible = false;
            viewModel.CanSaveOperation = false;
            form.ViewModel = viewModel;
            

            form.ChartFormShowMode = ChartFormShowMode.ShowCurrentOperation;

            UiHelper.ShowForm(form, mdiParent);
        }


        private void OnIdentifierPressureClick()
        {
            Form mdiParent = UiHelper.GetMdiContainer(this);

            IdentifierPressureForm form = (IdentifierPressureForm)UiHelper.GetFormSingle(typeof(IdentifierPressureForm));
            IdentifierPressureViewModel viewModel = new IdentifierPressureViewModel();
            form.ViewModel = viewModel;
            UiHelper.ShowForm(form, mdiParent);
        }

        private void zdButton14_Click(object sender, EventArgs e)
        {
            OnParametersClick();
        }


        private void OnParametersClick()
        {
            ShowParametersForm();
        }


        private void ShowParametersForm()
        {
            Form mdiParent = UiHelper.GetMdiContainer(this);

            Form form = UiHelper.GetFormSingle(typeof(ParametersForm));

            UiHelper.ShowForm(form, mdiParent);
        }


        private void zdToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            bool value = zdToggleButton1.Checked;

            OpcResponderSingleton.Instance.WriteBitToOpc(BitParameters.RuchnoRezhim, value);

            Cursor.Current = Cursors.Default;
        }


        private void zdButton8_Click_1(object sender, EventArgs e)
        {
            OnShowAutomateModeClick();
        }


        private void zdButton9_Click_1(object sender, EventArgs e)
        {
            OnIdentifierPressureClick();
        }


        private void zdToggleButton2_CheckedChanged(object sender, EventArgs e)
        {
            OnMoveToZeroPress();
        }


        private void OnMoveToZeroPress()
        {
            Cursor.Current = Cursors.WaitCursor;

            bool value = zdToggleButton2.Checked;

            OpcResponderSingleton.Instance.WriteBitToOpc(BitParameters.VihodV0Mon, value);

            Cursor.Current = Cursors.Default;
        }


        private void zdButton7_Click_1(object sender, EventArgs e)
        {
            OnOperationsClick();
        }


        private void OnOperationsClick()
        {
            Form form = UiHelper.GetFormSingle(typeof(OperationListForm));

            UiHelper.ShowForm(form, UiHelper.GetMdiContainer(this));
        }
    }
}
