using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace XamlInteg.ViewModels
{
    public class SfPickerPageViewModel : BindableBase
    {
        private ObservableCollection<object> selectedDateItem;

        private DateTime selectedDate;

        public ObservableCollection<object> SelectedDateItem { get => selectedDateItem; set => SetProperty(ref selectedDateItem, value); }

        public DateTime SelectedDate { get => selectedDate; set => SetProperty(ref selectedDate, value); }

        public DelegateCommand SelectedDateCommand { get; }

        public SfPickerPageViewModel()
        {
            SelectedDateCommand = new DelegateCommand(SelectedDateExecute);
            try
            {
                ObservableCollection<object> todaycollection = new ObservableCollection<object>();

                //Select today dates
                todaycollection.Add(DateTime.Now.Date.Year.ToString());
                todaycollection.Add($"{DateTime.Now.Date.Month}月");
                if (DateTime.Now.Date.Day < 10)
                    todaycollection.Add("0" + DateTime.Now.Date.Day);
                else
                    todaycollection.Add(DateTime.Now.Date.Day.ToString());

                this.SelectedDateItem = todaycollection;
            }
            catch (Exception ex)
            {
            }
        }

        private void SelectedDateExecute()
        {
            var dateTimeStr = $"{SelectedDateItem[0]}/{SelectedDateItem[1]}/{SelectedDateItem[2]}";
            this.SelectedDate = DateTime.ParseExact(dateTimeStr, "yyyy/M月/dd", new CultureInfo("zh-TW"));
        }
    }
}