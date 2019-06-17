public class Letter {
    private string text;
    private int pointValue;
    private int occurrenceCount;

    public Letter(string text, int occurrenceCount, int pointValue) {
        this.text = text;
        this.occurrenceCount = occurrenceCount;
        this.pointValue = pointValue;
    }

    public string getText() {
        return text;
    }

    public void setText(string text) {
        this.text = text;
    }

    public int getOccurrenceCount() {
        return occurrenceCount;
    }

    public void setOccurrenceCount(int occurrenceCount) {
        this.occurrenceCount = occurrenceCount;
    }

    public int getPointValue() {
        return pointValue;
    }

    public void setPointValue(int pointValue) {
        this.pointValue = pointValue;
    }
}
