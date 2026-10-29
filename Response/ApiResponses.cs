namespace EdgePanel.Response
{
    public record DataResponse<T>(T Data);

    public record ErrorResponse<E>(E Error);
}
