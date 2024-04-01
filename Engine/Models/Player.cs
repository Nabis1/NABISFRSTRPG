﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.ObjectModel;
namespace Engine.Models
{
    public class Player : LivingEntity
    {  
        #region Properties
        private int _experiencePoints;
        public int ExperiencePoints
        {
            get => _experiencePoints;
            private set
            {
                _experiencePoints = value;
                OnPropertyChanged();
                SetLevelAndMaximumHitPoints();
            }
        }
        public ObservableCollection<QuestStatus> Quests { get; } = new ObservableCollection<QuestStatus>();
        public ObservableCollection<Recipe> Recipes { get; } = new ObservableCollection<Recipe> { };
        #endregion
        public event EventHandler OnLeveledUp;
        public Player(string name,int experiencePoints,int maximumHitPoints,int currentHitPoints,IEnumerable<PlayerAttribute> attributes,int gold) : base(name,maximumHitPoints,currentHitPoints,attributes,gold)
        {
            ExperiencePoints = experiencePoints;
        }
        public void AddExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
        }
        public void LearnRecipe(Recipe recipe)
        {
            if (!Recipes.Any(r => r.ID == recipe.ID))
            {
                Recipes.Add(recipe);
            }
        }
        public void SetLevelAndMaximumHitPoints()
        {
            int originalLevel = Level;
            Level = (ExperiencePoints / 100) + 1;
            
            if (Level != originalLevel) 
            {
                MaximumHitPoints = Level * 10;
                OnLeveledUp?.Invoke(this, System.EventArgs.Empty);
            }
        }

    }
}
