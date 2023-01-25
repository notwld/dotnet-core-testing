import logo from './logo.svg';
import './App.css';
import Home from './Home';
import {TimeSlot} from './TimeSlot';
import {Course} from './Course';
import {BrowserRouter as Router, Route, Routes, NavLink} from 'react-router-dom';

function App() {
  return (
    <Router>
      <div className="App container">
        <h3 className="d-flex justify-content-center m-3">
          React JS Frontend
        </h3>
          
        <nav className="navbar navbar-expand-sm bg-light navbar-dark">
          <ul className="navbar-nav">
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/home">
                Home
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/TimeSlot">
                Time Slot
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/Course">
                Course
              </NavLink>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path='/Home' element={<Home/>}/>
          <Route path='/TimeSlot' element={<TimeSlot/>}/>
          <Route path='/Course' element={<Course/>}/>
        </Routes>
      </div>
    </Router>
  );
}

export default App;

