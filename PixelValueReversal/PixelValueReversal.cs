using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using OpenCvSharp;
using OpenCvSharp.Blob;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;
using OpenCvSharp.Utilities;

namespace PixelValueReversal {
	class PixelValueReversal {
		/// <summary>
		/// 入力パス
		/// </summary>
		private string InputPath = @"";

		/// <summary>
		/// 出力先パス
		/// </summary>
		private string OutputPath = @"";

		/// <summary>
		/// 入力先パス直下にある画像のパス
		/// </summary>
		private string[] ImagePathes;

		/// <summary>
		/// 1画素の範囲
		/// </summary>
		private byte PixelDepth = 255;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PixelValueReversal() {
			Console.WriteLine("base");
		} //End_Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="input"></param>
		/// <param name="output"></param>
		public PixelValueReversal(string input, string output) : this() {
			this.InputPath = input;
			this.OutputPath = output;
			Console.WriteLine("overload");
		} //End_Constructor

		/// <summary>
		/// ディレクトリ下の画像をすべて取得
		/// </summary>
		/// <returns></returns>
		public string[] GetImagePathes() {
			var filter = new Regex(".jpg|.jpeg|.gif|.bmp|.png");
			return Directory.GetFiles(this.InputPath,"*").ToArray();
			//return Directory.GetFiles(this.InputPath + "\\").Where(e => filter.IsMatch(e)).ToArray();
		} //End_Method

		/// <summary>
		/// 取得する
		/// </summary>
		public void Do() {
			this.ImagePathes = this.GetImagePathes();
			for(int i = 0; i < this.ImagePathes.Length; ++i) {
				var img = new Mat(this.ImagePathes[i]);
				Console.WriteLine("i=" + i + "  rows:" + img.Rows + "  cols:" + img.Cols);
				for(int y = 0; y < img.Rows; ++y) {
					for(int x = 0; x < img.Cols; ++x) {
						var pix = img.At<Vec3b>(y, x);
						pix[0] = (byte)(this.PixelDepth - pix[0]);
						pix[1] = (byte)( this.PixelDepth- pix[1]);
						pix[2] = (byte)(this.PixelDepth - pix[2]);
						img.Set<Vec3b>(y, x, pix);
					} //End_For
				} //End_For
				img.SaveImage(this.OutputPath + "\\" + this.ImagePathes[i].Split('\\').Last());
			} //End_For
		} //End_Method
	} //End_Class
} //End_Namespace