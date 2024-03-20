/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__int_array_41.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-41.tmpl.cs
*/
/*
 * @description
 * CWE: 476 Null Pointer Dereference
 * BadSource:  Set data to null
 * GoodSource: Set data to a non-null value
 * Sinks:
 *    GoodSink: add check to prevent possibility of null dereference
 *    BadSink : possibility of null dereference
 * Flow Variant: 41 Data flow: data passed as an argument from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__int_array_41 : AbstractTestCase
{
#if (!OMITBAD)
    private static void BadSink(int[] data )
    {
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.Length);
    }

    public override void Bad()
    {
        int[] data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        BadSink(data  );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    private static void GoodG2BSink(int[] data )
    {
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.Length);
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        int[] data;
        /* FIX: hardcode data to non-null */
        data = new int[5];
        GoodG2BSink(data  );
    }

    private static void GoodB2GSink(int[] data )
    {
        /* FIX: validate that data is non-null */
        if (data != null)
        {
            IO.WriteLine("" + data.Length);
        }
        else
        {
            IO.WriteLine("data is null");
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G()
    {
        int[] data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        GoodB2GSink(data  );
    }
#endif //omitgood
}
}
