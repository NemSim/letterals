using UnityEngine;
using System.Collections.Generic;

public class LetteralGenerator {

	public static List<Letteral> GenerateLetterals(string word) {
		
		Letteral[] letterals = new Letteral[word.Length];
		char[] characters = word.ToCharArray();

		float labelSize = Main.LetteralStyle.CalcSize(new GUIContent(word + "WWW")).x;

		for(int i=0; i<word.Length; i++){
			int newIndex = -1;
			while(newIndex == -1 || letterals[newIndex] != null){
				newIndex = (int) (word.Length * Random.value);
			}

			Vector2 endPos = new Vector2(((labelSize / (float) word.Length) * i) + ((Main.NativeWidth / 2) - (labelSize / 2)), Main.NativeHeight / 6f);
			Vector2 startPos = endPos + (new Vector2(Random.value * 2 - 1, Random.value * 2 - 1).normalized * (labelSize / 2));

			letterals[newIndex] = new Letteral(characters[i].ToString(), labelSize / word.Length, startPos, endPos);
		}

		return new List<Letteral>(letterals);
	}

	public static List<TitleLetteral> GenerateTitleLetterals() {

		string word = "LETTERALS";
		
		TitleLetteral[] letterals = new TitleLetteral[word.Length];
		char[] characters = word.ToCharArray();

		float labelSize = Main.TitleLetteralStyle.CalcSize(new GUIContent(word)).x;

		for(int i=0; i<word.Length; i++){
			Vector2 endPos = new Vector2(((labelSize / (float) word.Length) * i) + ((Main.NativeWidth / 2) - (labelSize / 2)), Main.NativeHeight / 20f);

			letterals[i] = new TitleLetteral(characters[i].ToString(), labelSize / word.Length, endPos);
		}

		return new List<TitleLetteral>(letterals);
	}

}