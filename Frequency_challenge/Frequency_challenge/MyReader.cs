///<summary>
///The class allows to file to be read and checks the frequency of
///the letters in the file,
///
/// </summary>














using System;
using static System.IO.StreamReader;
namespace Frequency_challenge
{
	public class MyReader : IFrequency

	{
		//
		private string file { get; set; }
		private List<string> Lines { get; set; }
		private List<char> characters { get; set; }
		private String[] words;
		private bool caseSantive;
        private int count { get; set; }
		private char[] letters;
		private int index = 0;
		private Dictionary<char, int> frequencyMap;
		/// <summary>
		/// constructor of the class
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="case_santive"></param>
        public MyReader(String filePath, bool case_santive) 
		{
			file = filePath;
			caseSantive = case_santive;
			

           Lines = new List<string>();
			
				
        }
		/// <summary>
		/// the method allows the file to be read and added to the file
		/// if caseSentive is equals false then the string is turn to lower case.
		/// </summary>
		public void Reader()
		{
			
			StreamReader reader = File.OpenText(file);
			reader.DiscardBufferedData();
			string line = reader.ReadLine();


			int linecount = 1;

			while (line != null)
			{
				if (!(line.StartsWith("{")) || !(line.EndsWith("}")))
					{
					int i = 0;
					if (!this.caseSantive)
					{
						line.ToLower();
						
					}

					Lines.Add(line);

                }


                line = reader.ReadLine();


				

			}
			reader.Close();
		}
		/// <summary>
		/// the words array is split and spilt again
		/// </summary>
		/// <returns></returns>
		public int WordSpilt()
		{
			int l = words.Length - 1;
			
            characters = new List<char>();
			for(int i = 0; i<l; i++)
			{
				if(i > 0)
				{
                    String word = words[i];
					if(!this.caseSantive)
					{
						word.ToLower();
					}
                    for (int j = 0; j < word.Length; j++)
                    {
                        characters.Add(word[j]);
                    }
                }
				
				
			}


            return characters.Count-1;
		}



    

  /// <summary>
  /// gets the number of characters in the list and splits them into a word array
  /// 
  /// </summary>
  /// <returns>inte</returns>

        public int NumberOfCharaters()

		{
			string lastLine = Lines[Lines.Count - 1];
			
			foreach(String line in Lines)

			{
				if(line.Contains(lastLine))
				{
					words = line.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
					
					index = WordSpilt();
					return index;
				
				}

				}
			return 0;
				
			}

			
			
		/// <summary>
		/// the method allows the it to shpw the frequency of the letters in the sentence that is given
		/// it adds it and sort and add the most frequencent letter the msc list
		/// 
		/// </summary>
		/// <returns> and returns it as a string </returns>
        
        public String UniqueValues()
        {
            frequencyMap = new Dictionary<char, int>();

            foreach (char c in characters)
            {
				int index = characters.IndexOf(c);
                if (frequencyMap.ContainsKey(c))
                {
                    frequencyMap[c]++;
                }
                else
                {
                    frequencyMap[c] = 1;
                }
            }

            List<KeyValuePair<char, int>> sortedFrequencyList = frequencyMap.ToList();
            sortedFrequencyList.Sort((x, y) => y.Value.CompareTo(x.Value));

            List<char> mostFrequentChars = new List<char>();

            for (int i = 0; i < Math.Min(sortedFrequencyList.Count, 10); i++)
            {
                mostFrequentChars.Add(sortedFrequencyList[i].Key);
            }

            if (mostFrequentChars.Count > 0)
            {
                string result = "Top 10 most frequent character(s):\n ";

                foreach (char mfc in mostFrequentChars)
                {
                    int count = frequencyMap[mfc];
                    result += mfc + " (Count: " + count + "), \n";
                }

                result = result.TrimEnd(',', ' ');
                return result;
            }

            return "No frequent characters found.";

            /*
			bool[] visited = new bool[words.Length];
			letters = characters.ToArray();
			Array.Sort(letters);
		 
			for(int i =0; i < letters.Length; i++)
			{
				if (visited[i]== true)
				{
					continue;
				}
				int countL = 1;
				for(int j = i + 1; j< letters.Length;j++)
				{
                    if (letters[i] == letters[j])
                    {
                        visited[j] = true;
                        countL++;
                    }


                }
				String total = letters[i].ToString()+ ":" + "\t"+"(" +countL +")"+"\n";
				int b =0;
				return total;
			}
			return "null";
			*/


        }

        public override String ToString()
		{
			String total = "total Character : " + NumberOfCharaters() +"\n";
			/*String w = "";
		    foreach(String word in words)
			{
				if(!word.StartsWith("\\"))
				{
					if)
					w += word;
				}
			}
			return total + w;
			//+ "\n" + uniqueValues() ;
			
			*/
			return this.caseSantive+"\n"+total +"\n"+ UniqueValues();

			

		}
    }
}

