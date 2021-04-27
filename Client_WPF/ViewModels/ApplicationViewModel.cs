using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Linq;
using Web_Service.Models;
using Client_WPF.Models;
using Microsoft.EntityFrameworkCore;

namespace Client_WPF.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public ApplicationViewModel()
        {
            db = new RestroomdbContext();
            dbSize = db.Place.Count();

            Place = new ObservableCollection<RestroomInfo>();
        }

        private readonly RestroomdbContext db;
        public int dbSize { get; private set; }
        public ObservableCollection<RestroomInfo> Place { get; set; }

        private RestroomInfo selectedWashroom;
        public RestroomInfo SelectedWashroom
        {
            get { return selectedWashroom; }
            set
            {
                selectedWashroom = value;
                OnPropertyChanged("");
            }
        }

        // команда подгрузки данных в список
        private RelayCommand downCommand;
        public RelayCommand DownCommand
        {
            get
            {
                return downCommand ??
                  (downCommand = new RelayCommand(obj =>
                  {
                      int sizeList = (int)obj;

                      if (sizeList == 0)
                          sizeList = 1;

                      if (sizeList + 10 >= dbSize)
                      {
                          for (int i = sizeList; i < dbSize; i++)
                          {
                              Place.Add(db.Place.Include(s => s.WorkingHours).FirstOrDefault(p => p.Id == i));
                          }
                      }
                      else
                      {
                          for (int i = sizeList; i < sizeList + 10; i++)
                          {
                              Place.Add(db.Place.Include(s => s.WorkingHours).FirstOrDefault(p => p.Id == i));
                          }
                      }
                  },
                 (obj) => Place.Count < dbSize));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}