using System;
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
		[RelayCommand]
        void Guess()
		{
			// if correct, then go to game over (DidWin=true)
			if (currentGuess == secretColor)
			{
				DidWin = true;
                Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
                currentGuess = "";
				Guesses.Clear();
            }
			// else if this is the 6th guess (and it's wrong)
			// then go to game over (DidWin=false)
			else if (Guesses.Count() == 6)
			{
                Guesses.Add(new ColorGuess(CurrentGuess));
                DidWin = false;
                Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
            }
            // Add this guess to the Guesses
            else if (Guesses.Count() < 6)
			{
				Guesses.Add(new ColorGuess(CurrentGuess));
			}
			//Reset Guess after its been added
			currentGuess = "";
			
		}


	}
}

