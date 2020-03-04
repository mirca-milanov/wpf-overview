using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace WpfOverview.Models
{
    class LineModel : INotifyPropertyChanged
    {
        private double x1;

        public double X1
        {
            get { return x1; }
            set
            {
                if (x1 != value)
                {
                    x1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("X1"));
                }
            }
        }
        private double x2;

        public double X2
        {
            get { return x2; }
            set
            {
                if (x2 != value)
                {
                    x2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("X2"));
                }
            }
        }
        private double y1;

        public double Y1
        {
            get { return y1; }
            set
            {
                if (y1 != value)
                {
                    y1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Y1"));
                }
            }
        }
        private double y2;

        public double Y2
        {
            get { return y2; }
            set
            {
                if (y2 != value)
                {
                    y2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Y2"));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
