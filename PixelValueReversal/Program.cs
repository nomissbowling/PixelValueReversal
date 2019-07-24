using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PixelValueReversal {
	class Program {
		static void Main(string[] args) {
			var input = @"J:\北風研究室\6年\dataset\3クラスAug";
			var output = @"C:\Users\tokab\Desktop\3クラスAug_色反転";

			var dirs = Directory.GetDirectories(input);
			foreach(var d in dirs) {
				var ngo = new PixelValueReversal(input + "\\" + d.Split('\\').Last(), output + "\\" + d.Split('\\').Last());
				ngo.Do();
			}
			
		} //End_Method
	} //End_Class
} //End_Namespace
