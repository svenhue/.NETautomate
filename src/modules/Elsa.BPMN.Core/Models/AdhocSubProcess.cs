
public class AdhocSubProcess : SubProcess {

    public static String ORDERING_PARALLEL = "Parallel";
    public static String ORDERING_SEQUENTIALL = "Sequential";

    protected String completionCondition;
    protected String ordering = ORDERING_PARALLEL;
    protected bool cancelRemainingInstances = true;

    public String getCompletionCondition() {
        return completionCondition;
    }

    public void setCompletionCondition(String completionCondition) {
        this.completionCondition = completionCondition;
    }

    public String getOrdering() {
        return ordering;
    }

    public void setOrdering(String ordering) {
        this.ordering = ordering;
    }

    public bool hasParallelOrdering() {
        return !ORDERING_SEQUENTIALL.Equals(ordering);
    }

    public bool hasSequentialOrdering() {
        return ORDERING_SEQUENTIALL.Equals(ordering);
    }

    public bool isCancelRemainingInstances() {
        return cancelRemainingInstances;
    }

    public void setCancelRemainingInstances(bool cancelRemainingInstances) {
        this.cancelRemainingInstances = cancelRemainingInstances;
    }
}
