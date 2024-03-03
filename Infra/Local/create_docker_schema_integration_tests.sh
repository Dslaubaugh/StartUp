#!/bin/bash

CURRENT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
WHITE='\033[0m'
RED='\033[0;31m'

function migrateDocker {
  pushd ${CURRENT_DIR}/../../
  docker compose up -d
  popd
}

function buildApplication {
  pushd ${CURRENT_DIR}/../../StartUp.Web
  dotnet clean
  dotnet build
  popd
}

function runIntegrationTest {
  pushd ${CURRENT_DIR}/../../StartUp.Web.IntegrationTests
  dotnet test --filter "Category=Integration"
  
  TEST_RESULT=$?
  if [[ ${TEST_RESULT} -ne 0 ]]; then
      echo -e "${RED}ERROR: Integration Tests Failed!!!${WHITE}"
      exit 1
  fi
  
  popd
}

function teardownDocker {
  pushd ${CURRENT_DIR}/../..
  docker compose down
  popd
}

migrateDocker
buildApplication
runIntegrationTest
teardownDocker