﻿using Milkitic.OsuPlayer.Data;
using Milkitic.OsuPlayer.ViewModels;
using Milkitic.OsuPlayer.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Milkitic.OsuPlayer.Pages
{
    /// <summary>
    /// EditCollectionPage.xaml 的交互逻辑
    /// </summary>
    public partial class EditCollectionPage : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly Collection _collection;

        public EditCollectionPage(MainWindow mainWindow, Collection collection)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _collection = collection;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Dispose();
            _mainWindow.FramePop.Navigate(null);
        }

        private void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel = (EditCollectionPageViewModel)DataContext;
            ViewModel.Name = _collection.Name;
            ViewModel.Description = _collection.Description;
            ViewModel.CoverPath = _collection.ImagePath;
        }

        public EditCollectionPageViewModel ViewModel { get; set; }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            _collection.Name = ViewModel.Name;
            _collection.Description = ViewModel.Description;
            _collection.ImagePath = ViewModel.CoverPath;

            DbOperator.UpdateCollection(_collection);
            BtnClose_Click(sender, e);
        }

        private void BtnChooseImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog
            {
                Title = @"请选择一个图片",
                Filter = @"所有支持的图片类型|*.jpg;*.png;*.jpeg"
            };
            var result = fbd.ShowDialog();
            if (result == true)
            {
                ViewModel.CoverPath = fbd.FileName;
            }
        }
    }
}
