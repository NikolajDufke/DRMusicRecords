import Axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index";

import {json2table100} from "./genericTable";

//let BaseUri: string = "https://localhost:44361/api/record"
let BaseUri: string = "https://drrecordsapi.azurewebsites.net/api/record"


interface IRecord {
   Title: string,
   Artist: string,
   Duration: number,
   YearOfPublication: number,
}

// ***Load all records at session start***
let newRecordElement: HTMLDivElement = <HTMLDivElement> document.getElementById("newRecord");
let newRecordinputFields: string 

newRecordinputFields = "<div class='container'>"+ MakeInputFields("title") + MakeInputFields("artist") + MakeInputFields("Duration") + MakeInputFields("YearOfPublication") + "</div>";
newRecordElement.innerHTML = newRecordinputFields;

function MakeInputFields(Name: string): string {
    return "<div class='row'>"+ "<span class='col' id=' title" + Name + "'> " + Name +" </span> <input class='col' id=' input" + Name + "'></input> <span class='col'></span>" + "</div>";
}

getAllRecords();

//Get all records and place in table_content
let content: HTMLDivElement = <HTMLDivElement> document.getElementById("table_content");

function getAllRecords(): void {
 Axios.get(BaseUri).then(
     function(respone: AxiosResponse): void{
    let data: IRecord[] = respone.data;
    let result: string = json2table100(data);
    content.innerHTML = result;
     }
 )
 .catch(
     function(error: AxiosError): void{
        content.innerHTML = error.message;
     }
 )    
}



 // ***Search implementation*** 
let searchButton : HTMLButtonElement = <HTMLButtonElement> document.getElementById("searchButton")
searchButton.addEventListener("click", Search);

function Search(): void {

let searchSelected : HTMLSelectElement = <HTMLSelectElement> document.getElementById("searchSelect");
let searchText : HTMLInputElement = <HTMLInputElement> document.getElementById("searchText");
let uristring: string = BaseUri + "/" + searchSelected.value + "/" + searchText.value;

if (searchText.value == "" || searchText.value == null)
{
getAllRecords();
}
else 
{
Axios.get(uristring).then(
    function(respone: AxiosResponse): void{
    let data: IRecord[] = respone.data;
    let result: string = json2table100(data);
    content.innerHTML = result;
     }
 )
 .catch(
     function(error: AxiosError): void{
         console.log(error.message);
         content.innerHTML = searchText.value + " could not be found";
     }
 )    
}     
}

// ***Add Record Implementation***
let buttonElement: HTMLButtonElement = <HTMLButtonElement> document.getElementById("addButton");
buttonElement.addEventListener("click", addRecord);

 function addRecord(): void {
    let title : HTMLInputElement = <HTMLInputElement> document.getElementById("inputtitle");
    let artist : HTMLInputElement = <HTMLInputElement> document.getElementById("inputauthor");
    let duration : HTMLInputElement = <HTMLInputElement> document.getElementById("inputDuration");
    let YearOfPublication : HTMLInputElement = <HTMLInputElement> document.getElementById("inputYearOfPublication");

Axios.post(BaseUri + 'Records', { 
    title : title.value,
    Artist : artist.value,
    duration : duration.value,
    YearOfPublication : YearOfPublication.valueAsNumber
}).then(function (response){
    console.log(response.data)
}).catch(function(error){
    console.log(error)
});
 }



 




