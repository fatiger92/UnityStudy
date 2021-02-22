using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class PlayFabLogin : MonoBehaviour //������ ����
{
    //public Dictionary<string, CatalogItem> m_dicCatalogItem = new Dictionary<string, CatalogItem>();  //������

    //public Dictionary<string, StoreItem> m_dicStoreItem = new Dictionary<string, StoreItem>(); // �� ���
    //public List<ItemInstance> playerInventory = new List<ItemInstance>();

    public void Start()
    {
        if (!string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true, };

            PlayFabClientAPI.LoginWithCustomID(request, OnLogin,
                (error) => {
                    Debug.LogError("�÷��� �� �α��� ����!!");
                    Debug.LogError(error.GenerateErrorReport());
                });
        }
    }

    /*
    public void Start()
    {
        if (!string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
            PlayFabClientAPI.LoginWithCustomID(request, OnLogin, 
                (error) => { 
                    Debug.LogError("�÷��� �� �α��� ����!!");
                    Debug.LogError(error.GenerateErrorReport());
                });
        }
    }
    */

    #region ��� �ϳ� ��� �ڵ�
    /*
        void OnLogin(LoginResult result)
        {
            Debug.Log("�÷��� �� �α��� ����!!");

            var request = new GetCatalogItemsRequest() { CatalogVersion = "main"};

            PlayFabClientAPI.GetCatalogItems(request, OnGetCatalogItem, 
                (error) => Debug.LogError(error.GenerateErrorReport()));
        }

        void OnGetCatalogItem(GetCatalogItemsResult result)
        {
            Debug.Log($"OnGetCatalogItem\n {result.ToJson()}");

            foreach (var item in result.Catalog)
            {
                m_dicCatalogItem.Add(item.ItemId, item);
            }

            if (m_dicCatalogItem.ContainsKey("apple"))
            {
                var item = m_dicCatalogItem["apple"];
                var request = new PurchaseItemRequest()
                {
                    CatalogVersion = item.CatalogVersion,
                    ItemId = item.ItemId,
                    VirtualCurrency = "GO",
                    Price = (int)item.VirtualCurrencyPrices["GO"],
                };

                PlayFabClientAPI.PurchaseItem(request, OnPurchaseItemSuccess, OnPurchaseItemFail);
            }
        }
        */
    #endregion

    #region ������ �� �ϳ� ��� �ڵ�
    /*
    void OnLogin(LoginResult result)
    {
        Debug.Log("�÷��� �� �α��� ����!!");

        var request = new GetStoreItemsRequest() { CatalogVersion = "main", StoreId = "fruits" };

        PlayFabClientAPI.GetStoreItems(request, OnGetStoreItem, (error) => Debug.LogError(error.GenerateErrorReport()));
    }
    
    void OnGetStoreItem(GetStoreItemsResult result)
    {
        Debug.Log($"OngetStoreItem\n{result.ToJson()}");

        foreach (var item in result.Store)
        {
            m_dicStoreItem.Add(item.ItemId, item);
        }

        if (m_dicStoreItem.ContainsKey("pear"))
        {
            var item = m_dicStoreItem["pear"];
            var request = new PurchaseItemRequest()
            {
                CatalogVersion = "main",
                StoreId = "fruits",
                ItemId = item.ItemId,
                VirtualCurrency = "GO",
                Price = (int)item.VirtualCurrencyPrices["GO"],
            };
            PlayFabClientAPI.PurchaseItem(request, OnPurchaseItemSuccess, OnPurchaseItemFail);
        }
    }
    
    void OnPurchaseItemSuccess(PurchaseItemResult result)
    {
        Debug.Log($"OnPurchaseItemSuccess\n{result.ToJson()}");

        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorty, (error) => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnPurchaseItemFail(PlayFabError error)
    {
        if (error.Error == PlayFabErrorCode.InsufficientFunds)
        {
            Debug.Log("�ܾ� ����");
        }
    }

    void OnGetUserInventorty(GetUserInventoryResult result)
    {
        Debug.Log($"OnGetUserInventorty\n{result.ToJson()}");
        playerInventory = result.Inventory;
    }
 */
    #endregion

    void OnLogin(LoginResult result)
    {
        Debug.Log("�÷��� �� �α��� ����!!");

        var request = new ExecuteCloudScriptRequest()
        {
            FunctionName = "bushelOnYourFirstDay",
            GeneratePlayStreamEvent = true,  // true�̸� �̺�Ʈ�� �����Ǿ� PlayStream �ֿܼ��� Ȯ���� �� �ִ�.
        };

        PlayFabClientAPI.ExecuteCloudScript(request, OnBushelOnYourFirstDay, (error) => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnBushelOnYourFirstDay(ExecuteCloudScriptResult result)
    {
        Debug.LogFormat($"OnBushelOnYourFirstDay\n {result.Logs[0].Level} : {result.Logs[0].Message}");
    }
}