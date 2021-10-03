
const root = 'C:/github/UoS-hub/frontend/'
const parse = require('csv-parse')
var fs = require('fs');



let json = {};
fs.createReadStream(root + 'sites.csv')
    .pipe(parse({delimiter: ','}))
    .on('data', function(row) {
        //do something with csvrow

        json[row[0]] = {
          name : row[1],
          buildings : {}
        };

    })
    .on('end',function() {
      //do something with csvData
      readBuildings();

    })
    .on('error', function(e){
      //console.log(e);
    });


function readBuildings(){
  fs.createReadStream(root + 'buildings.csv')
      .pipe(parse({delimiter: ','}))
      .on('data', function(row) {
          //do something with csvrow

          try{
            json[row[2]].buildings[row[0]] = {
              name : row[1],
              latitude : row[4],
              longitude : row[5],
              year_of_completion : row[6],
              residential : row[7] == 'Yes'
            }
          }catch(e){
            //console.log(row + ' - ' + e)
          };

      })
      .on('end',function() {
        //do something with csvData

        write_file(json);
      })
      .on('error', function(e){
        //console.log(e);
      });
}


function write_file(content){
  fs.writeFile(root + 'result.json', JSON.stringify(content), err => {
    if(err) {
      console.error(err);
      return;
    }
  })
}






















// const express = require('express')
// const app = express()
// const path = require('path')
//
// const port = 3000
//
// app.use(express.static('public'))
//
// app.get('/', (req, res) => {
//   res.sendFile(path.join(__dirname + '/public/index.html'));
// })
//
//
//
//
// app.listen(port, () => {
//   console.log('app started')
// })
