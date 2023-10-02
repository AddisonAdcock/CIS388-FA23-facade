﻿using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace facade
{
	public partial class MainPageViewModel: ObservableObject 
	{
		[ObservableProperty]
		private string secretColor;

		[ObservableProperty]
		private string currentGuess;

		public ObservableCollection<ColorGuess> Guesses { get; set; }
        public bool DidWin { get; private set; }

        //public string SecretColor { get; set; }

        public MainPageViewModel()
		{
			secretColor = "FACADE";
			currentGuess = "";
			
			Guesses = new ObservableCollection<ColorGuess>();
			Guesses.Add(new ColorGuess("#beaded") );
            Guesses.Add(new ColorGuess("#facade"));
        }


		[RelayCommand]
		void AddLetter(string letter)
		{
			if( CurrentGuess.Length < 6)
			{
				CurrentGuess += letter;
			}
		}


		[RelayCommand]
        void RemoveLetter()
        {
            if (CurrentGuess.Length < 6 && CurrentGuess.Length > 0)
            {
                CurrentGuess = CurrentGuess.Remove(CurrentGuess.Length - 1);
            }
        }

        void Guess()
		{
			// if correct, then go to game over (DidWin=true)
			if (currentGuess == secretColor)
			{
				DidWin = true;
			}
			else if (Guesses.Count() ==  6){
				DidWin = false;
			}
			// else if this is the 6th guess (and it's wrong)
			// then go to game over (DidWin=false)


			// Add this guess to the Guesses
			Guesses.Add(new ColorGuess (CurrentGuess));
			
		}


	}
}

