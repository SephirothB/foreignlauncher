using System;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Asktoclose : Form
    {
        /// <summary>
        /// The following functions are only binds to close the launcher or what so ever
        /// </summary>
        public Asktoclose() => InitializeComponent();
        private void close_Click(object sender, EventArgs e) => Close();
        private void cancelBtn_Click(object sender, EventArgs e) => Close();
        private void confirm_Click(object sender, EventArgs e) => Environment.Exit(1);
        private void Asktoclose_Load(object sender, EventArgs e) => TopMost = true;
    }
}
