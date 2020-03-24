import Axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index";

import {json2table100} from "./genericTable";

let BaseUri: string = "https://localhost:44361/api/record"
let contentElement: HTMLDivElement = <HTMLDivElement> document.getElementById("content");
let element: HTMLDivElement = <HTMLDivElement> document.getElementById("table_content");
let AllRecords: JSON;



interface IRecord {
   Title: string,
   Artist: string,
   Duration: number,
   YearOfPublication: number,
}

let newRecordElement: HTMLDivElement = <HTMLDivElement> document.getElementById("newRecord");

let newRecordinputFields: string 





// let Record1 = Object.create(Record)
// console.log(Object.keys(Record1));
// // Object.keys(Record).forEach(element => {
// //     console.log(element); 
// // });



newRecordinputFields = "<div class='container'>"+ MakeInputFields("title") + MakeInputFields("artist") + MakeInputFields("Duration") + MakeInputFields("YearOfPublication") + "</div>";


console.log(MakeInputFields("title"))

newRecordElement.innerHTML = newRecordinputFields;

 


function MakeInputFields(Name: string): string {
    return "<div class='row'>"+ "<span class='col' id=' title" + Name + "'> " + Name +" </span> <input class='col' id=' input" + Name + "'></input> <span class='col'></span>" + "</div>";
}

// let sentence: string = `Hello, my name is ${ fullName }

console.log("Getting localitems");
Axios.get(BaseUri).then(
    function(response :AxiosResponse) : void{
      
        console.log(response.data)
    }
)
.catch(
    function(error: AxiosError):void{
        console.log(error.message)
        console.log(error.response)
        console.log(error.stack)

    }
)


 Axios.get(BaseUri).then(
     function(respone: AxiosResponse): void{
         console.log("getting Records... v15");
         console.log(Date.now)
        //  element.innerHTML = "<div class='spinner-border text-muted></div>";
        //  setTimeout(() => {  console.log("waited 5 sek"); }, 5000);
    let data: IRecord[] = respone.data;
        console.log(data);
    let result: string = json2table100(data);
console.log(result);
     element.innerHTML = result;
        // contentElement.innerHTML = JSON.stringify(respone.data);
     }
 )
 .catch(
     function(error: AxiosError): void{
        contentElement.innerHTML = error.message;
     }
 )

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



 




