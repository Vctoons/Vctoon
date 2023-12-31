﻿using Avalonia.Controls;
using Avalonia.Interactivity;
using EasyDialog.Avalonia.Dialogs;
using VctoonClient.Dialogs;
using VctoonClient.ViewModels;

namespace VctoonClient.Layouts.Main;

public partial class MainContent : UserControl
{
    private MainViewModel _vm;

    public MainContent()
    {
        InitializeComponent();
        this.UseEasyLoading(DialogConsts.MainViewContentIdentifier)
            .UseEasyDialog(DialogConsts.MainViewContentIdentifier);
        _vm = App.Services.GetService<MainViewModel>()!;
        DataContext = _vm;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        var topLevel = TopLevel.GetTopLevel(this);

        if (topLevel != null)
        {
            topLevel.BackRequested += TopLevel_BackRequested;
        }
    }

    private async void TopLevel_BackRequested(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as MainViewModel;

        if (viewModel != null)
        {
            if (_vm.Router.CanGoBack)
            {
                e.Handled = true;

                await _vm.Router.BackAsync();
            }
        }
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        base.OnUnloaded(e);
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel != null)
        {
            topLevel.BackRequested -= TopLevel_BackRequested;
        }
    }
}