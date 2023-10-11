import * as React from 'react';
import Button from '@mui/material/Button';

export default function Botao(props) {
  return (
    <Button variant="contained" key={props.id} onClick={props.onClick} value={props.value} size="small">
      {props.children}
    </Button>
  );
}