import React from 'react';
import { variables } from './Variables.js';

export class TimeSlot extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            timeslots: [],
            rooms: [],
            modalTitle: "",
            TSCode: "",
            StartTime: "",
            EndTime: "",
            RoomId: "",
            TSId: 0,
            RoomId: 0,
            RoomName: ""

        }
    }

    refreshList() {
        fetch(variables.API_URL + 'timeslot')
            .then(response => response.json())
            .then(data => {
                this.setState({ timeslots: data });
            });
    }

    refreshRoom() {
        fetch(variables.API_URL + 'Room')
            .then(response => response.json())
            .then(data => {
                console.log(data)
                this.setState({ rooms: data });
            });
    }

    componentDidMount() {
        this.refreshList();
        this.refreshRoom();
    }

    changeTSCode = (e) => {
        this.setState({ TSCode: e.target.value });
    }

    changeStartTime = (e) => {
        this.setState({ StartTime: e.target.value });
    }

    changeEndTime = (e) => {
        this.setState({ EndTime: e.target.value });
    }

    changeRoomId = (e) => {
        this.setState({ RoomId: e.target.value });
        console.log(this.state.RoomId)
    }

    addClick() {
        this.setState({
            modalTitle: 'Add TimeSlot',
            TSId: 0,
            TSCode: "",
            StartTime: "",
            EndTime: "",
            RoomId: ""
        });
    }

    editClick(ts) {
        this.setState({
            modalTitle: 'Edit TimeSlot',
            TSId: ts.TSId,
            TSCode: ts.TSCode,
            StartTime: ts.StartTime,
            EndTime: ts.EndTime,
            RoomId: ts.RoomId

        });
    }

    createClick() {
        fetch(variables.API_URL + 'timeslot', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                TSCode: this.state.TSCode,
                StartTime: this.state.StartTime,
                EndTime: this.state.EndTime,
                RoomId: this.state.RoomId

            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            })
    }

    updateClick() {
        fetch(variables.API_URL + 'timeslot', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                TSId: this.state.TSId,
                TSCode: this.state.TSCode,
                StartTime: this.state.StartTime,
                EndTime: this.state.EndTime,
                RoomId: this.state.RoomId
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            })
    }

    deleteClick(ts) {
        if (window.confirm('Are you Sure to Delete?')) {
            fetch(variables.API_URL + 'timeslot', {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    TSId: ts.TSId
                })
            })
                .then(res => res.json())
                .then((result) => {
                    alert(result);
                    this.refreshList();
                }, (error) => {
                    alert('Failed');
                })
        }
    }

    render() {
        const {
            timeslots,
            modalTitle,
            TSId,
            TSCode,
            StartTime,
            EndTime,
            RoomId,
            RoomName,
            rooms
        } = this.state;

        return (
            <div>
                <button type='button'
                    className='btn btn-primary m-2 float-end'
                    data-bs-toggle="modal"
                    data-bs-target="#exampleModal"
                    onClick={() => this.addClick()}>
                    Add TimeSlot
                </button>
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>Time Slot Id</th>
                            <th>Time Slot Code</th>
                            <th>Start Time</th>
                            <th>End Time</th>
                            <th>Room Name</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            timeslots.map(ts =>
                                <tr key={ts.TSId}>
                                    <td>{ts.TSId}</td>
                                    <td>{ts.TSCode}</td>
                                    <td>{ts.StartTime}</td>
                                    <td>{ts.EndTime}</td>
                                    <td>{ts.RoomName}</td>
                                    <td>
                                        <button type="button"
                                            className="btn btn-light mr-1"
                                            data-bs-toggle="modal"
                                            data-bs-target="#exampleModal"
                                            onClick={() => this.editClick(ts)}>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                                <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                            </svg>
                                        </button>
                                        <button type="button"
                                            className="btn btn-light mr-1"
                                            onClick={() => this.deleteClick(ts)}>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                                <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                            </svg>
                                        </button>
                                    </td>
                                </tr>
                            )
                        }
                    </tbody>
                </table>

                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
                    <div className="modal-dialog modal-lg modal-dialog-centered">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">{modalTitle}</h5>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>

                            <div className="modal-body">
                                <div className="input-group mb-3">
                                    <span className="input-group-text">Time Slot Code</span>
                                    <input type="text" className="form-control" value={TSCode} onChange={this.changeTSCode} />
                                </div>

                                <div className="input-group mb-3">
                                    <span className="input-group-text">Start Time</span>
                                    <input type="text" className="form-control" value={StartTime} onChange={this.changeStartTime} />
                                </div>

                                <div className="input-group mb-3">
                                    <span className="input-group-text">End Time</span>
                                    <input type="text" className="form-control" value={EndTime} onChange={this.changeEndTime} />
                                </div>
                                <div class="input-group mb-3">
                                    <label class="input-group-text" for="inputGroupSelect01">Rooms</label>
                                    <select class="form-select" id="inputGroupSelect01" select onChange={(e)=>{this.changeRoomId(e)}}>
                
                                    {rooms.map((r)=>{
                                        return(
                                        <option value={r.RoomId}>{r.RoomId}</option>
                                        )
                                    })}
                                    </select>
                                </div>
                                {/* <label for="rooms">Choose a Room:</label>

                                <select name="rooms" id="rooms">
                                    
                                </select> */}
                                {TSId == 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.createClick()}
                                    >Create</button>
                                    : null}

                                {TSId != 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.updateClick()}
                                    >Update</button>
                                    : null}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}



