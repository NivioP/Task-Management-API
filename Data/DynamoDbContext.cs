using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

public class DynamoDbContext {
    private readonly IAmazonDynamoDB _dynamoDb;
    private readonly string _tableName;

    public DynamoDbContext(IAmazonDynamoDB dynamoDb, IConfiguration configuration) {
        _dynamoDb = dynamoDb;
        _tableName = configuration["AWS:DynamoDbTableName"];
    }

    public async Task AddTaskAsync(TaskEntity task) {
        var request = new PutItemRequest {
            TableName = _tableName,
            Item = new Dictionary<string, AttributeValue> {
                { "Id", new AttributeValue { S = task.Id } },
                { "Title", new AttributeValue { S = task.Title } },
                { "Description", new AttributeValue { S = task.Description } },
                { "DueDate", new AttributeValue { S = task.DueDate.ToString() } },
                { "Priority", new AttributeValue { S = task.Priority } },
                { "Status", new AttributeValue { S = task.Status } }
            }
        };

        await _dynamoDb.PutItemAsync(request);
    }

    public async Task<List<TaskEntity>> GetAllTasksAsync() {
        var request = new ScanRequest {
            TableName = _tableName
        };

        var response = await _dynamoDb.ScanAsync(request);
        return response.Items.Select(MapToTask).ToList();
    }

    public async Task<TaskEntity> GetTaskByIdAsync(string id) {
        var request = new GetItemRequest {
            TableName = _tableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { S = id } }
            }
        };

        var response = await _dynamoDb.GetItemAsync(request);
        return MapToTask(response.Item);
    }

    public async Task UpdateTaskAsync(TaskEntity task) {
        var request = new PutItemRequest {
            TableName = _tableName,
            Item = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { S = task.Id } },
                { "Title", new AttributeValue { S = task.Title } },
                { "Description", new AttributeValue { S = task.Description } },
                { "DueDate", new AttributeValue { S = task.DueDate.ToString() } },
                { "Priority", new AttributeValue { S = task.Priority } },
                { "Status", new AttributeValue { S = task.Status } }
            }
        };

        await _dynamoDb.PutItemAsync(request);
    }

    private TaskEntity MapToTask(Dictionary<string, AttributeValue> item) {
        if (item == null || !item.Any()) {
            return null;
        }

        return new TaskEntity {
            Id = item["Id"].S,
            Title = item["Title"].S,
            Description = item["Description"].S,
            DueDate = DateTime.Parse(item["DueDate"].S),
            Priority = item["Priority"].S,
            Status = item["Status"].S
        };
    }
}

