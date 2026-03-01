eclass CacheSerializer:
    """
    Standardized serialization for
    cache values
    """
    @staticmethod
    def serialize(value):
        """
        Serialize value to string
        with type preservation
        """
        if value is None:
            return None
        type_hint = type(value).__name__
    serialized = json.dumps({
        'type': type_hint,
        'value': value
    })
    return serialized
@staticmethod
def deserialize(serialized):
    """
    Deserialize value with
    type restoration
    """
    if serialized is None:
        return None
    data = json.loads(serialized)
    value = data['value']
    # Handle special types
    if data['type'] == 'datetime':
        return datetime.datetime.fromisoformat(
            value
        )
    elif data['type'] == 'date':
        return datetime.date.fromisoformat(
            value
        )
    return value
