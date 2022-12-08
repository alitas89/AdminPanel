
namespace AdminPanle.BusinessLayer.Other.Response;
public class ObjectResponse<DataType>
    where DataType : class
{
    private readonly DataType? _data;
    private readonly string _message;
    private readonly bool _succes;

    public DataType? Data => _data;
    public string Message => _message;
    /// <summary>
    /// Sıkıntısız şekilde data verildiyse Success true olur diğer durumlarda false
    /// </summary>
    public bool Success => _succes;

    private ObjectResponse(DataType? data, string message, bool succes)
    {

        
        if (((message == null || message.Trim().Equals("")) && data == null) ||
            (data is IEnumerable<object> a && a.Count()<=0))
        {
            _data = null;
            _message = "Nesne veya nesneler gelmedi";
            _succes = false;
        }
        else
        {
            _data = data;
            _message = message!;
            _succes = succes;
        }
    }

    /// <summary>
    /// Data verilmiş ise Succes true yapılır ve mesaj boş olur
    /// </summary>
    /// <param name="data"></param>
    public ObjectResponse(DataType? data) : this(data, string.Empty, true)
    {
    }

    /// <summary>
    /// Mesaj verilmiş ise succes false yapılır ve data null olur
    /// </summary>
    /// <param name="message"></param>
    public ObjectResponse(string message) : this(null, message, false)
    {
    }

}

