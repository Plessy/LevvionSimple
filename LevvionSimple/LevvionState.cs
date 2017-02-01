using System.Collections.Generic;

namespace LevvionSimple
{
	/// <summary>
	/// A class that holds the state of the AI in LevvionSimple.
	/// </summary>
	public class LevvionState 
	{
		/// <summary>
		/// The _bools
		/// </summary>
		private Dictionary<string, bool> _bools;

		/// <summary>
		/// The bytes
		/// </summary>
		private Dictionary<string, byte> _bytes;

		/// <summary>
		/// The _ints
		/// </summary>
		private Dictionary<string, int> _ints;

		/// <summary>
		/// The _floats
		/// </summary>
		private Dictionary<string, float> _floats;

		/// <summary>
		/// The _strings
		/// </summary>
		private Dictionary<string, string> _strings;

		/// <summary>
		/// Initializes a new instance of the <see cref="LevvionState"/> class.
		/// </summary>
		public LevvionState()
		{
			_bools = new Dictionary<string, bool>();
			_bytes = new Dictionary<string, byte>();
			_ints = new Dictionary<string, int>();
			_floats = new Dictionary<string, float>();
			_strings = new Dictionary<string, string>();
		}

		/// <summary>
		/// Sets a boolean value.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">if set to <c>true</c> [value].</param>
		public void SetBool(string id, bool value)
		{
			_bools.Remove(id);
			_bools.Add(id, value);
		}

		/// <summary>
		/// Sets a byte value.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		public void SetByte(string id, byte value)
		{
			_bytes.Remove(id);
			_bytes.Add(id, value);
		}

		/// <summary>
		/// Sets an integer value.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		public void SetInt(string id, int value)
		{
			_ints.Remove(id);
			_ints.Add(id, value);
		}

		/// <summary>
		/// Sets a float value.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		public void SetFloat(string id, float value)
		{
			_floats.Remove(id);
			_floats.Add(id, value);
		}

		/// <summary>
		/// Sets a string value.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		public void SetString(string id, string value)
		{
			_strings.Remove(id);
			_strings.Add(id, value);
		}
		
		/// <summary>
		/// Gets a bool by ID. Default value is false.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public bool GetBool(string id)
		{
			if (_bools.ContainsKey(id))
			{
				return _bools[id];
			}

			return false;
		}
		
		/// <summary>
		/// Gets a byte by ID. Default value is 0.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public byte GetByte(string id)
		{
			if (_bytes.ContainsKey(id))
			{
				return _bytes[id];
			}

			return 0;
		}
		
		/// <summary>
		/// Gets an int by ID. Default value is 0.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public int GetInt(string id)
		{
			if (_ints.ContainsKey(id))
			{
				return _ints[id];
			}

			return 0;
		}
		
		/// <summary>
		/// Gets a float by ID. Default value is 0.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public float GetFloat(string id)
		{
			if (_floats.ContainsKey(id))
			{
				return _floats[id];
			}

			return 0;
		}
		
		/// <summary>
		/// Gets a string by ID. Default value is "".
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public string GetString(string id)
		{
			if (_strings.ContainsKey(id))
			{
				return _strings[id];
			}

			//Return "" instead of null so I don't expect everything to handle null.
			return "";
		}
	}
}
