using System.Collections;

namespace SqlTransfTests.dataGenerators.SqlTransfDataAccess;

public class PasswordData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{"Sifra1" };
        yield return new object[]{"SqlTransfLibExamplePass" };
        yield return new object[]{"3234nknjkn234njk2n3" };
        yield return new object[]{"!@$_@(#@932" };
        yield return new object[]{"testnasifra!@2" };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}