import "bootstrap/dist/css/bootstrap.min.css"
import {BrowserRouter as Router, Route, Routes, Navigate, Outlet} from 'react-router-dom';
import CreateUser from "./pages/CreateUser";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Profile from "./pages/Profile";
import NotFound from "./pages/NotFound";
import { parseJwt } from "./services/auth";

function App() {

  const token = localStorage.getItem('usuario-login') 

  const Geral = () => {
    return (

      token !== null && parseJwt(token).role === '1' || parseJwt(token).role === '2'|| parseJwt(token).role === '3' ? 
      <Outlet /> :
      <Navigate to={{pathname:'/login'}}/>
      
    )
    }

  const AdminRoot = () => {
   return (
        token !== null && parseJwt(token).role === '2'|| parseJwt(token).role === '3' ? 
        <Outlet /> :
        <Navigate to={{pathname : '/login'}} />  
      
   )
}
   



  return (
    <Router>
   <Routes>

     <Route exact path='/' element={<Home/>} />


      <Route path="/Login" element={<Login/>} />


      <Route element={<Geral/>}
       >
      <Route path="/Profile" element={<Profile/>} />
      </Route >

      <Route element={ <AdminRoot/>} >
      <Route  path="/CreateUser" element={<CreateUser/>} />
      </Route >

      <Route path="/404" element ={<NotFound />}/>
      <Route path="*" element={<Navigate replace to="/404" />} />
      </Routes>
  </Router>
)
}

export default App;
