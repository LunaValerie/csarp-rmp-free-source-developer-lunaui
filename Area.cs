using RPM.hModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPM.Hyper
{
    public partial class Area : Form
    {
        public Area()
        {
            InitializeComponent();
        }
        private void UnityPlayerdll()
        {
            if (Process.GetProcessesByName("PixelStrike3D").Length == 0)
            {Application.Exit();
                return;
            }else{try {Process process = Process.GetProcessesByName("PixelStrike3D")[0];
             foreach (ProcessModule module in process.Modules)
             {if (module.FileName.IndexOf(myFileName.Uprdll) != -1)
             {GlobalCheats.UnityPlayer = module.BaseAddress.ToString();}}
            }catch (Exception ex){MessageBox.Show("Sisteminiz 0x32 bit olamaz !" + ex.ToString());}}
        }
        private void GameAssemblydll()
        {
            if (Process.GetProcessesByName("PixelStrike3D").Length == 0)
            {Application.Exit();return;}else{
            try{Process process = Process.GetProcessesByName("PixelStrike3D")[0];
            foreach (ProcessModule module in process.Modules){
            if (module.FileName.IndexOf(myFileName.Gydll) != -1){
            GlobalCheats.GameAssembly = module.BaseAddress.ToString();}}}
            catch (Exception ex){MessageBox.Show("Beklenmedik Bir hata olustu !" + ex.ToString());}}
        }
        private void hModule()
        {
            Convert.ToInt64(GlobalCheats.UnityPlayer.ToLower());
            label1.Text = "GameAssembly.dll" + "+" + "0x" + GlobalCheats.GameAssembly.ToString();
            label2.Text = "UnityPlayer.dll" + "+" + "0x" + GlobalCheats.UnityPlayer.ToString();
            Convert.ToInt64(GlobalCheats.GameAssembly.ToLower());
        }

        private void main()
        {
            Random myreallyrandom = new Random();
            int hm = myreallyrandom.Next(20, 50);
            myrandom.Text = hm.ToString();
        }


        private void AutoModule_Tick(object sender, EventArgs e)
        {
            UnityPlayerdll();
            GameAssemblydll();
            hModule();
            main();
        }
    }
}
