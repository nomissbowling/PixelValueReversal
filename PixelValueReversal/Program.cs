using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PixelValueReversal {
	class Program {
		static void Main(string[] args) {
			var input = @"C:\Users\tokab\Desktop\3クラス_テスト\未知画像\Kawau";
			var output = @"C:\Users\tokab\Desktop\3クラス_テスト_output";


			var ngo = new PixelValueReversal(input, output);
			ngo.Do();
		} //End_Method
	} //End_Class
} //End_Namespace
