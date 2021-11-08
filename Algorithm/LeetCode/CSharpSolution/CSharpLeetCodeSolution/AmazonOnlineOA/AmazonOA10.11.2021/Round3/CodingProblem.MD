
```C#
class TaskDefinition {
    private string Name;
    private List<Tag> tags;
    private List<TaskDefinition> tasks;
}


class Tag {
    private string key;
    private string value;
}
```

Validate Rules
* Task Definition must have name;
* Tasks at least have one element;
* Tag must have both fields set; 