
using Elsa.BPMN.Core.Models;


public class TextAnnotation : Artifact {

    protected String text;
    protected String textFormat;

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    public String getTextFormat() {
        return textFormat;
    }

    public void setTextFormat(String textFormat) {
        this.textFormat = textFormat;
    }

  
    public override TextAnnotation Clone() {
        TextAnnotation clone = new TextAnnotation();
        clone.setValues(this);
        return clone;
    }

    public void setValues(TextAnnotation otherElement) {
        base.SetValues(otherElement);
        setText(otherElement.getText());
        setTextFormat(otherElement.getTextFormat());
    }
}
