using System.Text.Json;
using SerializationIndentationOptions;

Console.WriteLine("Agora no .NET é possível formatar como desejamos serializar o json.");
Console.WriteLine("Digite 1 para aplicar o recuo em Tabs.");
Console.WriteLine("Digite 2 para aplicar o recuo em espaços.");
Console.WriteLine("Digite 3 para aplicar o recuo com o Default web options.");

var key = Console.ReadLine();
var type = key == "1" ? "TABs": "Spaces";
var indentSize = 0;

if(key != "3") {
    Console.WriteLine($"Agora informe a quantidade de recuo que você deseja { type }.");
    indentSize = int.Parse(Console.ReadLine() ?? "0");
}

switch (key)
{
    case "1":
        SerializeWithTabIdent(indentSize);
        return;
    case "2":
        SerializeWithSpaceIdent(indentSize);
        return;
    case "3":
        SerializeWithOptionsWeb();
        return;
    default:
        Console.WriteLine("Opção incorreta");
        return;
}


void SerializeWithTabIdent(int indentSize) 
{
    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IndentCharacter = '\t',
        IndentSize = indentSize,
    };


    var result = JsonSerializer.Serialize(
        new People(Guid.NewGuid(), "Marcos Lima", 25),
        options
    );

    Console.WriteLine(result);
}

void SerializeWithSpaceIdent(int indentSize) 
{
    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IndentCharacter = ' ',
        IndentSize = indentSize,
    };


    var result = JsonSerializer.Serialize(
        new People(Guid.NewGuid(), "Marcos Lima", 25),
        options
    );

    Console.WriteLine(result);
}

void SerializeWithOptionsWeb() 
{
    var result = JsonSerializer.Serialize(
        new People(Guid.NewGuid(), "Marcos Lima", 25),
        JsonSerializerOptions.Web
    );

    Console.WriteLine(result);
}
