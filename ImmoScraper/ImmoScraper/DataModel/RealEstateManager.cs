namespace ImmoScraper.DataModel;

public class RealEstateManager
{
    private List<RealEstate> RealEstateList = new();

    public void bulkAddData()
        => throw new NotImplementedException();

    /// <summary>
    /// check befor adding realestate to list, if realestate is already in List
    /// </summary>
    /// <param name="realEstate"></param>
    public void addData(RealEstate realEstate)
    {
        // TODO: Checklogic

        realEstate.isDuplicate = false;
        int index = 0;
        
        foreach (RealEstate realEstateItem in RealEstateList)
        {
            /*
             * check if there is a realestate existing in List and if there is a existing
             * realEstate - add an id and set isDuplicate - true otherwise false
             * checked on address, count of rooms, phonenumber 
             */

            if (realEstateItem.ort.Equals(realEstate.ort)
                && realEstateItem.strasse.Equals(realEstate.strasse)
                && realEstateItem.phoneNumber.Equals(realEstate.phoneNumber))
            {
                realEstate.isDuplicate = true;
                realEstate.idOfFirstDupliciate = index;
            }

            ++index;
        }

        RealEstateList.Add(realEstate);
    }
}