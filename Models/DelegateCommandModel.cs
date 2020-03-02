using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOverview.Commands;

namespace WpfOverview.Models
{
    public class DelegateCommandModel
    {
        public DelegateCommand PrintStuff { get; set; } = new DelegateCommand((o) => { MessageBox.Show("Hello."); }, null);
    }
}
