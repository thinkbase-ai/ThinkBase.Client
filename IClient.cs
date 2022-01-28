﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBase.Client.GraphModels;

namespace ThinkBase.Client
{
    public interface IClient
    {
        Task<long> ClearAllKnowledgeStates();
        Task<KnowledgeState?> CreateKnowledgeState(KnowledgeState ks, bool? asSystem = false, bool transient = false);
        Task<List<KnowledgeState>> CreateKnowledgeStateBatched(List<KnowledgeState> ksl, bool transient = false);
        Task<String?> ExportNodaModel();
        Task<GraphModel> FetchModel();
        Task<GraphAttribute?> GetGraphAttributeByAttName(KnowledgeState ks, string nodeName, string attName);
        Task<GraphAttribute?> GetGraphAttributeByLineage(KnowledgeState ks, string nodeName, string lineage);
        Task<KnowledgeState?> GetKnowledgeState(string subjectId);
        Task<List<Interaction>> Interact(string conversationId, string message);
        Task SetConnectionPresence(KnowledgeState ks, string nodeName, string destName, string remoteSubjectId);
        Task SetDataValue(KnowledgeState ks, string nodeName, string attName, string value);
        Task SetObjectExistence(KnowledgeState ks, string nodeName, List<DarlTime> existence);
        Task<IObservable<KnowledgeState>> SubscribeToSeek(string nodeName);
    }
}
