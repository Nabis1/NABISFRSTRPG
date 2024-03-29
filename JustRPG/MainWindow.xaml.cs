﻿using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Input;
using Engine.EventArgs;
using Engine.Models;
using Engine.Services;
using Engine.ViewModels;
namespace WPFUI

{

    public partial class MainWindow : Window
    {
        private readonly MessageBroker _messageBroker = MessageBroker.GetInstance();
        private readonly GameSession _gameSession = new GameSession();
        private readonly Dictionary<Key, Action> _userImputActions = new Dictionary<Key, Action>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeUserInputActions();
            _gameSession = SaveGameService.LoadLastSaveOrCreateNew();
            _messageBroker.OnMessageRaised += OnGameMessageRaised;
            DataContext = _gameSession;
        }
    
        private void OnClick_MoveNorth(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveNorth();
        }
        private void OnClick_MoveWest(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveWest();
        }
        private void OnClick_MoveEast(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveEast();
        }
        private void OnClick_MoveSouth(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveSouth();
        }
        private void OnClick_AttackMonster(object sender, RoutedEventArgs e)
        {
            _gameSession.AttackCurrentMonster();
        }
        private void OnClick_UseCurrentConsumable(object sender, RoutedEventArgs e)
        {
            _gameSession.UseCurrentConsumable();
        }
        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }
        private void OnClick_DisplayTradeScreen(object sender, RoutedEventArgs e)
        {
            if (_gameSession.CurrentTrader != null)
            {
                TradeScreen tradeScreen = new TradeScreen();
                tradeScreen.Owner = this;
                tradeScreen.DataContext = _gameSession;
                tradeScreen.ShowDialog();
            }
        }
        private void OnClick_Craft(object sender, RoutedEventArgs e)
        {
            Recipe recipe = ((FrameworkElement)sender).DataContext as Recipe;
            _gameSession.CraftItemUsing(recipe);
        }
        private void InitializeUserInputActions()
        {
            _userImputActions.Add(Key.W, () => _gameSession.MoveNorth());
            _userImputActions.Add(Key.A, () => _gameSession.MoveWest());
            _userImputActions.Add(Key.D, () => _gameSession.MoveEast());
            _userImputActions.Add(Key.S, () => _gameSession.MoveSouth());
            _userImputActions.Add(Key.Z, () => _gameSession.AttackCurrentMonster());
            _userImputActions.Add(Key.C, () => _gameSession.UseCurrentConsumable());
            _userImputActions.Add(Key.I, () => SetTabFocusTo("InventoryTabItem"));
            _userImputActions.Add(Key.Q, () => SetTabFocusTo("QuestTabItem"));
            _userImputActions.Add(Key.R, () => SetTabFocusTo("RecipesTabItem"));
            _userImputActions.Add(Key.T, () => OnClick_DisplayTradeScreen(this, new RoutedEventArgs()));
        }
        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if(_userImputActions.ContainsKey(e.Key))
            {
                _userImputActions[e.Key].Invoke();
            }
        }
        private void SetTabFocusTo(string tabName)
        {
            foreach (object item in PlayerDataTabControl.Items)
            {
                if (item is TabItem tabItem)
                {
                    if (tabItem.Name == tabName)
                    {
                        tabItem.IsSelected = true;
                        return;
                    }
                }
            }
        }
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            SaveGameService.Save(_gameSession);
        }
    }
    

}