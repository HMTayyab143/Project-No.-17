using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Amount of instructions DOSBox tries to emulate each millisecond.
    /// </summary>
    public struct CPUCycles
    {
        #region "Constructions"

        /// <summary>
        /// Create a CPYCycles with number of cycles to each mullisecond
        /// </summary>
        /// <param name="cycles">Number of cycles to each mullisecond</param>
        public CPUCycles(uint cycles)
        {
            Cycles = cycles;
        }

        /// <summary>
        ///  Create a CPYCycles with string number of cycles to each mullisecond
        /// </summary>
        /// <param name="cycles">Number of cycles to each mullisecond or max | auto</param>
        public CPUCycles(string cycles)
        {
            if (cycles == null || cycles.ToLower() == "auto")
                Cycles = 0;

            if (cycles.ToLower() == "max")
                Cycles = uint.MaxValue;

            var fixedValue = cycles.Replace("fixed", "").Trim();

            if (uint.TryParse(fixedValue, out uint result))
            {
                Cycles = result;
            }

            throw new NotSupportedException("String is not a CPU Cycles");
        }

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// Sets the emulated CPU speed to a fixed amount of cycles
        /// </summary>
        public uint Cycles { get; set; }

        #endregion "Properties"

        #region "String Casts"

        /// <summary>
        /// Cast CPUCycles to string
        /// </summary>
        /// <returns>String of CPUCycles</returns>
        public override string ToString()
        {
            if (Cycles == 0)
                return "auto";

            if (Cycles == uint.MaxValue)
                return "max";

            return $"fixed {Cycles}";
        }

        /// <summary>
        /// Implicit cast from CPUCycles struct to string
        /// </summary>
        /// <param name="cycles">CPUCycles instance</param>
        public static implicit operator string(CPUCycles cycles)
        {
            return cycles.ToString();
        }

        /// <summary>
        /// Explicit cast from string to CPUCycles struct
        /// </summary>
        /// <param name="cycles">CPUCycles string</param>
        public static explicit operator CPUCycles(string cycles)
        {
            return new CPUCycles(cycles);
        }

        #endregion "String Casts"

        #region "Operator Overloading"

        /// <summary>
        /// The equality operator, returns true if its CPUCycles are equal, false otherwise.
        /// </summary>
        /// <param name="cycles1">First CPYCycles</param>
        /// <param name="cycles2">Second CPUCycles</param>
        /// <returns>True if its CPUCycles are equal, false otherwise</returns>
        public static bool operator ==(CPUCycles cycles1, CPUCycles cycles2)
        {
            return cycles1.Cycles == cycles2.Cycles;
        }

        /// <summary>
        /// The inequality operator, returns true if its CPUCycles are not equal, false otherwise. 
        /// </summary>
        /// <param name="cycles1">First CPYCycles</param>
        /// <param name="cycles2">Second CPUCycles</param>
        /// <returns>True if its CPUCycles are not equal, false otherwise.</returns>
        public static bool operator !=(CPUCycles cycles1, CPUCycles cycles2)
        {
            return cycles1.Cycles != cycles2.Cycles;
        }

        /// <summary>
        /// The > operator returns true if its left-hand CPUCycles is greater than its right-hand CPUCycles, false otherwise:
        /// </summary>
        /// <param name="cycles1">First CPYCycles</param>
        /// <param name="cycles2">Second CPUCycles</param>
        /// <returns>True if its left-hand CPUCycles is greater</returns>
        public static bool operator >(CPUCycles cycles1, CPUCycles cycles2)
        {
            return cycles1.Cycles > cycles2.Cycles;
        }

        /// <summary>
        /// The &lt; operator returns true if its left-hand CPUCycles is less than its right-hand CPUCycles, false otherwise
        /// </summary>
        /// <param name="cycles1">First CPYCycles</param>
        /// <param name="cycles2">Second CPUCycles</param>
        /// <returns>True if its left-hand CPUCycles is less</returns>
        public static bool operator <(CPUCycles cycles1, CPUCycles cycles2)
        {
            return cycles1.Cycles < cycles2.Cycles;
        }

        /// <summary>
        /// The >= operator returns true if its left-hand CPUCycles is greater than or equal to its right-hand CPUCycles, false otherwise
        /// </summary>
        /// <param name="cycles1">First CPYCycles</param>
        /// <param name="cycles2">Second CPUCycles</param>
        /// <returns>True if its left-hand CPUCycles is greater than or equal</returns>
        public static bool operator >=(CPUCycles cycles1, CPUCycles cycles2)
        {
            return cycles1.Cycles >= cycles2.Cycles;
        }

        /// <summary>
        /// The &lt;= operator returns true if its left-hand CPUCycles is less than or equal to its right-hand CPUCycles, false otherwise
        /// </summary>
        /// <param name="cycles1">First CPYCycles</param>
        /// <param name="cycles2">Second CPUCycles</param>
        /// <returns>True if its left-hand CPUCycles is less than or equal</returns>
        public static bool operator <=(CPUCycles cycles1, CPUCycles cycles2)
        {
            return cycles1.Cycles <= cycles2.Cycles;
        }

        /// <summary>
        ///  The equality function, returns true if its CPUCycles are equal, false otherwise.
        /// </summary>
        /// <param name="obj">Compare object</param>
        /// <returns>True if its CPUCycles are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj is CPUCycles)
                return this.Cycles == ((CPUCycles)obj).Cycles;
            
            return base.Equals(obj);
        }

        /// <summary>
        /// Return the hash code for this instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Cycles.GetHashCode();
        }

        #endregion "Operator Overloading"

        #region "UInt Cast"

        /// <summary>
        /// Implicit cast from CPUCycles struct to string
        /// </summary>
        /// <param name="cycles">CPUCycles instance</param>
        public static implicit operator uint(CPUCycles cycles)
        {
            return cycles.Cycles;
        }

        /// <summary>
        /// Implicit cast from string to CPUCycles struct.
        /// </summary>
        /// <param name="cycles">CPUCycles string</param>
        public static implicit operator CPUCycles(uint cycles)
        {
            return new CPUCycles(cycles);
        }

        #endregion "UInt Cast"
    }
}
