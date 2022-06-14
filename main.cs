//====================================================================================
// SlimSharp Pre-roll. Use this section at the top of your SlimSharp source file
//====================================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using S = System.String;
using I = System.Int32;
using D = System.Double;
using T = System.DateTime;
using U = System.UInt32;
using O = System.Object;

using static SSUtil;

System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());

//===================================================================================
// End Pre-Roll.


//===================================================================================
// Begin SlimSharp code here
//===================================================================================





//===================================================================================
// Stop SlimSharp code here
//===================================================================================


//===================================================================================
// SlimSharp Post-Roll. Include this code at the bottom of your SlimSharp source file
//
public static class SSUtil
{
    // TODO: all overloads
    public static void P(S s) { System.Diagnostics.Trace.WriteLine(s); }
    public static void p(S s) { System.Diagnostics.Trace.Write(s); }
    public static void P(O s) { System.Diagnostics.Trace.WriteLine(s); }
    public static void p(O s) {System.Diagnostics.Trace.Write(s); }
    
    public static S R() => Console.ReadLine();
    public static S R(S prompt) { p(prompt); return R(); }

    public static I RI() => IP(R());
    public static D RD() => DP(R());
    public static T RT() => TP(R());

    public static I RI(S prompt) => IP(R(prompt));
    public static D RD(S prompt) => DP(R(prompt));
    public static T RT(S prompt) => TP(R(prompt));

    public static I RI(S prompt, int MaxTries) { while (MaxTries > 0) { try { return RI(prompt); } catch { MaxTries--; } } throw new Exception("Out of tries"); }
    public static D RD(S prompt, int MaxTries) { while (MaxTries > 0) { try { return RD(prompt); } catch { MaxTries--; } } throw new Exception("Out of tries"); }
    public static T RT(S prompt, int MaxTries) { while (MaxTries > 0) { try { return RT(prompt); } catch { MaxTries--; } } throw new Exception("Out of tries"); }

    //TODO: other Replace() overloads
    public static S R(this S s, S oldValue, S newValue ) =>  s.Replace(oldValue, newValue);

    public static S S(this S s, I startIndex) => s.Substring(startIndex);
    public static S S(this S s, I startIndex, I length) => s.Substring(startIndex, length);

    //TODO: other IndexOf() overloads
    public static I I(this S s, S value) => s.IndexOf(value);
    public static I I(this S s, S value, I startIndex) => s.IndexOf(value, startIndex);
    public static I I(this S s, S value, I startIndex, I count) => s.IndexOf(value, startIndex, count);

    //TODO: CultureInfo overloads for ToUpper()/ToLower()
    public static S l(this S s) => s.ToLower();
    public static S U(this S s) => s.ToUpper();

    //TODO: Trim() overloads
    public static S T(this S s) => s.Trim();

    //TODO: convice C# language team to add extension property support
    public static I L(this S s) => s.Length;
    public static I IMx() =>  Int32.MaxValue;
    public static I IMn() => Int32.MinValue;
    public static D DMx() => D.MaxValue;
    public static D DMn() => D.MinValue;

    public static I L<T>(this IList<T> items) => items.Count;
    public static I L<T>(this T[] items) => items.Length;
    public static I L<T>(this IEnumerable<T> items) => items.Count();

    //TODO: Find a way to add a static method to a sealed type. May need to change the spec instead :(
    public static I IP(S s) => Int32.Parse(s);
    public static D DP(S s) => D.Parse(s);
    public static T TP(S s) => DateTime.Parse(s);
    
    //ToString() shorteners
    public static S s(this O o) => o.ToString();
	public static S s(this I i, S f) => i.ToString(f);
	public static S s(this D d, S f) => d.ToString(f);
	public static S s(this T t, S f) => t.ToString(f);
	public static S s(this U u, S f) => u.ToString(f);
}
