using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine.Models
{
        public class QuestStatus : INotifyPropertyChanged
    { 
            private bool _isCompleted;
            public Quest PlayerQuest { get; }

        public event PropertyChangedEventHandler PropertyChanged;
            public bool IsCompleted
         {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
            }
         }

        public QuestStatus(Quest quest)
            {
                PlayerQuest = quest;
                IsCompleted = false;
            }
        }
    }
