﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThinkBase.Client.GraphModels;

namespace ThinkBase.Client
{
    public interface IClient
    {
        Task<long> ClearAllKnowledgeStates();
        Task<GraphConnection> CreateGraphConnection(GraphConnection gc);
        Task<GraphObject> CreateGraphObject(GraphObject go);
        Task<bool> CreateKGraph();
        Task<KnowledgeState?> CreateKnowledgeState(KnowledgeState ks, bool? asSystem = false, bool transient = false);
        Task<List<KnowledgeState>> CreateKnowledgeStateBatched(List<KnowledgeState> ksl, bool transient = false);
        Task<bool> DeleteKGraph();
        Task<KnowledgeState?> DeleteKnowledgeState(string subjectId, bool asSystem = false);
        Task<String?> ExportNodaModel();
        Task<GraphModel> FetchModel(bool asSystem = false);
        Task<List<KnowledgeState>> GetChildKnowledgeStates(string parentId, bool asSystem);
        Task<List<KnowledgeState>> GetChildKnowledgeStatesWithAttributeValue(string parentId, string attLineage, string attValue, bool asSystem);
        Task<GraphAttribute?> GetGraphAttributeByAttName(KnowledgeState ks, string nodeName, string attName);
        Task<GraphAttribute?> GetGraphAttributeByLineage(KnowledgeState ks, string nodeName, string lineage);
        Task<KnowledgeState?> GetInteractKnowledgeState(string conversationId);
        Task<KnowledgeState?> GetKnowledgeState(string subjectId);
        Task<List<Interaction>> Interact(string conversationId, string message);
        Task<int?> MailShot(string collateral, string subject, string sendfrom, bool test);
        Task<string?> NodaView();
        Task SetConnectionPresence(KnowledgeState ks, string nodeName, string destName, string remoteSubjectId);
        Task SetDataValue(KnowledgeState ks, string nodeName, string attName, string value);
        Task SetObjectExistence(KnowledgeState ks, string nodeName, List<DarlTime> existence);
        IObservable<DarlMineReport> SubscribeToBuild(string name, string? data, string? patternPath, List<DataMap> dataMaps);
        Task<IObservable<KnowledgeStateInput>> SubscribeToSeek(string nodeName);
        Task<bool> DeleteAttributeByName(string ObjectName, string AttName);
        Task<bool> AddAttributeByName(string ObjectName, GraphAttribute att);
        Task<bool> AddSubAttributeByName(string ObjectName, string AttName, GraphAttribute subAtt);
        Task<bool> DeleteSubAttributeByName(string ObjectName, string AttName, string subAttName);
        Task<byte[]> DownloadGraph();
        Task<string> UploadGraph(byte[] content);
    }
}
