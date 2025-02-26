
using Elsa.BPMN.Core.Models;
using Microsoft.VisualBasic;

public class DateDataObject : ValuedDataObject {


    public override void SetValue(Object value) {
    	if (value.GetType().Equals(typeof(String)) && String.IsNullOrEmpty(value.ToString().Trim()) == false ) {
    		try {
				this.value = DateTime.Parse(value.ToString());
			} catch (Exception e) {
				Console.WriteLine("Error parsing Date string: " + value);
			}
    	} else if (value.GetType().Equals(typeof(DateTime))) {
    		this.value = value;
    	}
    }


    public override DateDataObject Clone() {
        DateDataObject clone = new DateDataObject();
        clone.setValues(this);
        return clone;
    }
}
