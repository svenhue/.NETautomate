
public class TimerEventDefinition : EventDefinition {

    protected String timeDate;
    protected String timeDuration;
    protected String timeCycle;
    protected String endDate;
    protected String calendarName;

    public String getTimeDate() {
        return timeDate;
    }

    public void setTimeDate(String timeDate) {
        this.timeDate = timeDate;
    }

    public String getTimeDuration() {
        return timeDuration;
    }

    public void setTimeDuration(String timeDuration) {
        this.timeDuration = timeDuration;
    }

    public String getTimeCycle() {
        return timeCycle;
    }

    public void setTimeCycle(String timeCycle) {
        this.timeCycle = timeCycle;
    }

    public void setEndDate(String endDate) {
        this.endDate = endDate;
    }

    public String getEndDate() {
        return endDate;
    }

    public String getCalendarName() {
        return calendarName;
    }

    public void setCalendarName(String calendarName) {
        this.calendarName = calendarName;
    }

    public override TimerEventDefinition Clone() {
        TimerEventDefinition clone = new TimerEventDefinition();
        clone.setValues(this);
        return clone;
    }

    public void setValues(TimerEventDefinition otherDefinition) {
        base.SetValues(otherDefinition);
        setTimeDate(otherDefinition.getTimeDate());
        setTimeDuration(otherDefinition.getTimeDuration());
        setTimeCycle(otherDefinition.getTimeCycle());
        setEndDate(otherDefinition.getEndDate());
        setCalendarName(otherDefinition.getCalendarName());
    }
}
