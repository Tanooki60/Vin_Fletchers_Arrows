//I feel I may have gotten the input for this incorrectly. This was the only way I could think of to get the information needed to pass to the Arrow constructor.

string arrowSelection = UserInput("Choose an arrowhead type (steel, wood, obsidian): ");
string fletchingSelection = UserInput("Choose an fletching type (plastic, turkey, goose): ");
float lengthSelection = Convert.ToInt16(UserInput("How long would you like the length (between 60 and 100): "));

Arrow arrow = new Arrow(arrowSelection, fletchingSelection, lengthSelection);
float arrowCost = arrow.GetArrowHead(arrowSelection);
float fletchingCost = arrow.GetFletching(fletchingSelection);
float shaftLength = arrow.GetLength(lengthSelection);

var arrowTotalCost = arrow.GetCost(arrowCost, fletchingCost, shaftLength);

string UserInput(string text)
{
    Console.WriteLine(text);
    return Console.ReadLine();
}
class Arrow
{
    public string _arrow;
    public string _fletching;
    public float _length;

    public Arrow(string arrow, string fletching, float length)
    {
        _arrow = arrow;
        _fletching = fletching; 
        _length = length;
    }

    public float GetArrowHead(string input)
    {
        return input switch

        {
            "steel" => (float)Arrowhead.Steel,
            "wood" => (float)Arrowhead.Wood,
            "osidian" => (float)Arrowhead.Obsidian
        };
    }

    public float GetFletching(string input) 
    {
        return input switch

        {
            "plastic" => (float)Fletching.Plastic,
            "turkey" => (float)Fletching.Turkey,
            "goose" => (float)Fletching.Goose
        };
    }

    public float GetLength(float input) 
    {
        return (float)Convert.ToInt16(input);
    }

    public float GetCost(float arrowheadCost, float fletchingCost, float totalLength) 
    {
        //The parenthesis aren't needed, but I find it is easier to read.
        float totalCost = (float)arrowheadCost + fletchingCost + (totalLength * 0.05F);
        
        Console.WriteLine($"The total cost is {totalCost}.");
        return totalCost;        
    }
}
//Assigned values to the enums to use for the cost.
enum Arrowhead { Steel = 10, Wood = 3, Obsidian = 5 }
enum Fletching { Plastic = 10, Turkey = 5, Goose = 3 }