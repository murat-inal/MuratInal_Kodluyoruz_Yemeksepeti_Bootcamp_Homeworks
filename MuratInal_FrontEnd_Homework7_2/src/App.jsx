import React, { useState } from "react";
import List from "./Components/List";
import Form from "./Components/Form";
import Header from "./Components/Header";

function App() {
  const [todos, setTodos] = React.useState([]);

  const addTodo = (text) => {
    const newTodos = [{ text }, ...todos];
    setTodos(newTodos);
  };

  const deleteTodo = (index) => {
    const newTodos = [...todos];
    newTodos.splice(index, 1);
    setTodos(newTodos);
  };

  return (
    <div>
      <Header/>
      <div className="todo-list">
      <Form addTodo={addTodo} />
        {todos.map((todo, index) => (
          <List key={index} index={index} todo={todo} deleteTodo={deleteTodo} />
        ))}        
      </div>
    </div>
  );
}

export default App;
