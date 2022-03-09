using Cinema.Service;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cinema.VM
{
    public class VMBaseNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private IDataManager dataManager;

        public IDataManager DataManager
        {
            get { return dataManager; }
            set
            {
                dataManager = value;
                OnPropertyChanged("DataManager");
            }
        }
    }
}
