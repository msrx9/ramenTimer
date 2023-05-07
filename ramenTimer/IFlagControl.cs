using System;
namespace ramenTimer
{
	public interface IFlagControl
	{
		/// <summary>
		/// 入力されたBoolフラグをトグル
		/// </summary>
		/// <param name="flag"></param>
		/// <returns>入力されたBool値を反転した値</returns>
		public bool Toggle(bool flag);

		/// <summary>
		/// 指定したタイマーがタイムアウトしたか判定
		/// </summary>
		/// <param name="leftTime"></param>
		/// <returns>true: タイムアウト, false: カウントダウン中</returns>
		public bool IsTimeout(TimeOnly leftTime);
	}
}

