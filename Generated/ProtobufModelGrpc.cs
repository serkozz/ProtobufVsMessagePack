// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protobufModel.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ProtobufVsMessagePack.ProtobufModel {
  public static partial class EmployeeService
  {
    static readonly string __ServiceName = "ProtobufVsMessagePack.ProtobufModel.EmployeeService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ProtobufVsMessagePack.ProtobufModel.EmployeeRequest> __Marshaller_ProtobufVsMessagePack_ProtobufModel_EmployeeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProtobufVsMessagePack.ProtobufModel.EmployeeRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ProtobufVsMessagePack.ProtobufModel.EmployeeResponse> __Marshaller_ProtobufVsMessagePack_ProtobufModel_EmployeeResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProtobufVsMessagePack.ProtobufModel.EmployeeResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ProtobufVsMessagePack.ProtobufModel.EmployeeRequest, global::ProtobufVsMessagePack.ProtobufModel.EmployeeResponse> __Method_GetEmployee = new grpc::Method<global::ProtobufVsMessagePack.ProtobufModel.EmployeeRequest, global::ProtobufVsMessagePack.ProtobufModel.EmployeeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetEmployee",
        __Marshaller_ProtobufVsMessagePack_ProtobufModel_EmployeeRequest,
        __Marshaller_ProtobufVsMessagePack_ProtobufModel_EmployeeResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ProtobufVsMessagePack.ProtobufModel.ProtobufModelReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of EmployeeService</summary>
    [grpc::BindServiceMethod(typeof(EmployeeService), "BindService")]
    public abstract partial class EmployeeServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ProtobufVsMessagePack.ProtobufModel.EmployeeResponse> GetEmployee(global::ProtobufVsMessagePack.ProtobufModel.EmployeeRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(EmployeeServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetEmployee, serviceImpl.GetEmployee).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, EmployeeServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetEmployee, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ProtobufVsMessagePack.ProtobufModel.EmployeeRequest, global::ProtobufVsMessagePack.ProtobufModel.EmployeeResponse>(serviceImpl.GetEmployee));
    }

  }
}
#endregion
