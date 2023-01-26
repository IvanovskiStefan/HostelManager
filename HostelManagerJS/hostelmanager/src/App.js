import {useState} from "react"
import './App.css';

function App() {
const [hostels,setHostels] = useState();
const [hostelName,setHostelName] = useState("");
const[hostelAddress,setHostelAddress]=useState("");


const addRoom = (hotel) =>{
  fetch("https://localhost:7294/api/v1/Rooms/add-room",{
    method:"POST",
    cache: 'no-cache', 
  credentials: 'same-origin', 
  headers: {
    'Content-Type': 'application/json'
    
  },
  body:JSON.stringify({
    //hardcoded adding rooms for test
  id: Math.floor(Math.random() * 1000000000) + 1,
  capacity: 5,
  isAvailable: true,
  hostelId: hotel.id
  })
  
  })
  
}

  const getAllHostels= () =>{
    fetch("https://localhost:7294/api/v1/Hostel/get-all")
    .then(res => res.json())
    .then(data => setHostels(data))
  } 

  const removeHostel = (hostel) =>{
    fetch(`https://localhost:7294/api/v1/Hostel/delete-hostel/${hostel.id}`, {
    method:"DELETE",
    cache: 'no-cache', 
  credentials: 'same-origin', 
  headers: {
    'Content-Type': 'application/json'
    
  },
    
  })

  }
  const addHostel = () =>{
    fetch(`https://localhost:7294/api/v1/Hostel/add-hostel`, {
      method:"POST",
      cache: 'no-cache', 
    credentials: 'same-origin', 
    headers: {
      'Content-Type': 'application/json'
    },
      body:JSON.stringify({
        hostelName : hostelName,
        address : hostelAddress,
        
      })
    })  }

 
  return (
    <div>
      <button onClick = {getAllHostels}>Get all hostels</button>
      {hostels && hostels.map((hostel)=>{
        return (
          <div key = {hostel.id} > 
           Hostel name : {hostel.hostelName} <br></br>Hostel address :{hostel.address}

            <button onClick={()=>removeHostel(hostel)}>Delete selected hostel</button>
            <button onClick={()=>addRoom(hostel)} >Add Room to the selected hostel</button>
          </div>
      
        )
      })}
      

      <div>
      <input name="hostel" value={hostelName} type="text" onChange = {(e)=>{
          setHostelName(e.target.value)
        }} placeholder="enter hotel name"></input>
        <input name="hostelAddress" value={hostelAddress} type="text" onChange={(e)=>{
          setHostelAddress(e.target.value)
        }}></input>
        <button onClick={addHostel} >Add hostel</button>
        
      </div>
    </div>
  );
}

export default App;
