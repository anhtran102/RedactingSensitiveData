using Microsoft.Extensions.Compliance.Redaction;

namespace AnhTran.RedactingSensitiveData.Redactors
{
    public class MarkAllRedactor : Redactor
    {
        private const char _mask = '*';
        //string maskValue = "*****";
        public override int GetRedactedLength(ReadOnlySpan<char> input)
        {
            return input.Length;
            //return maskValue.Length;
        }

        public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
        {
            destination.Fill(_mask);            
            //maskValue.CopyTo(destination);            
            return destination.Length;
        }
    }
}
