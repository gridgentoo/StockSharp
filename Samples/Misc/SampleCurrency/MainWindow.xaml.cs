﻿#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: SampleCurrency.SampleCurrencyPublic
File: MainWindow.xaml.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace SampleCurrency
{
	using System.Windows;

	using Ecng.Common;
	using Ecng.Xaml;

	using StockSharp.Messages;

	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();

			SourceCurrencyType.SetItemsSource<CurrencyTypes>();
			TargetCurrencyType.SetItemsSource<CurrencyTypes>();

			SourceCurrencyType.SetSelected(CurrencyTypes.USD);
			TargetCurrencyType.SetSelected(CurrencyTypes.RUB);
		}

		private void ConvertClick(object sender, RoutedEventArgs e)
		{
			var currency = new Currency
			{
				Type = SourceCurrencyType.GetSelected<CurrencyTypes>(),
				Value = Amount.Text.To<decimal>(),
			};

			Result.Content = currency.Convert(TargetCurrencyType.GetSelected<CurrencyTypes>()).Value;
		}
	}
}